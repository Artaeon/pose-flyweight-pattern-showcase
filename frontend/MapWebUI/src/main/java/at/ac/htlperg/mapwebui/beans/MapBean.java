package at.ac.htlperg.mapwebui.beans;

import at.ac.htlperg.mapwebui.helper.ConfigReader;
import at.ac.htlperg.mapwebui.helper.GoogleMapsInitializer;
import at.ac.htlperg.mapwebui.model.LoactionTypeFactory;
import com.company.model.Review;
import jakarta.annotation.PostConstruct;
import jakarta.inject.Inject;
import org.eclipse.microprofile.rest.client.inject.RestClient;
import com.company.api.LocationsApi;
import com.company.model.Location;
import com.company.model.LocationDto;
import com.company.model.LocationTypesDto;

import jakarta.faces.view.ViewScoped;
import jakarta.inject.Named;
import org.primefaces.model.map.DefaultMapModel;
import org.primefaces.model.map.LatLng;
import org.primefaces.model.map.MapModel;
import org.primefaces.model.map.Marker;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@Named
@ViewScoped
public class MapBean implements Serializable {
    @Inject
    @RestClient
    private LocationsApi locationsApi;
    //API results
    private List<LocationDto> locations;

    private LoactionTypeFactory loactionTypeFactory;

    //Map
    private MapModel mapModel;

    //dialog
    private String title;
    private double lat;
    private double lng;
    private LocationTypesDto locationType = null;
    private Map<String, LocationTypesDto> locationTypesDropdown;


    private String apiKey;

    @PostConstruct
    public void init() {
        this.apiKey = ConfigReader.readKeyConfig();
        mapModel = new DefaultMapModel();

        loactionTypeFactory = new LoactionTypeFactory(locationsApi);
        locationTypesDropdown = loactionTypeFactory.loadDropdown();
        fetchLocations();
        loadMarkers();
    }

    private void loadMarkers(){
        if (locations != null) {
            for (LocationDto location : locations) {
                Marker marker = createMarker(location);
                mapModel.addOverlay(marker);
            }
        }
    }

    private Marker createMarker(LocationDto location) {
        LatLng coord = new LatLng(location.getLatitude(), location.getLongitude());

        LocationTypesDto locationType = loactionTypeFactory.findLocationType(location.getLocationType());

        String icon = (locationType != null) ? locationType.getIconPath() : null;

        return new Marker(coord, location.getName(), null, icon);
    }


    public void addMarker(){
        Location location = new Location();

        location.setLongitude(lng);
        location.setLatitude(lat);
        /*
        location.setLocationId(0);

        location.setLocationTypeId(0);
        location.setLocationType(locationType);
        */
        location.setName(title);
        location.setReviews(new ArrayList<Review>());

        System.out.println(location.toString());
    }

    public void fetchLocations() {
        try {
            locations = locationsApi.apiLocationsGet();
        } catch (Exception e) {
            System.out.println(e);
        }
    }

    public void addLocation(Location location) {
        try {
            locationsApi.apiLocationsAddLocationPost(location);

            fetchLocations();
        } catch (Exception e) {
            System.out.println(e);
        }
    }

    public void updateLocation(Integer id, Location location) {
        try {
            locationsApi.apiLocationsUpdateLocationIdPut(id, location);

            fetchLocations();
        } catch (Exception e) {
            System.out.println(e);
        }
    }

    // Getters and setters

    public List<LocationDto> getLocations() {
        return locations;
    }

    public void setLocations(List<LocationDto> locations) {
        this.locations = locations;
    }

    public String getApiKey() {
        return apiKey;
    }

    public void setApiKey(String apiKey) {
        this.apiKey = apiKey;
    }

    public MapModel<String> getMapModel() {
        return mapModel;
    }

    public void setMapModel(MapModel<String> mapModel) {
        this.mapModel = mapModel;
    }

    public String getTitle() {
        return title;
    }
    public void setTitle(String title) {
        this.title = title;
    }
    public double getLat() {
        return lat;
    }
    public void setLat(double lat) {
        this.lat = lat;
    }
    public double getLng() {
        return lng;
    }
    public void setLng(double lng) {
        this.lng = lng;
    }
    public LocationTypesDto getLocationType() {
        return locationType;
    }

    public void setLocationType(LocationTypesDto locationType) {
        this.locationType = locationType;
    }

    public Map<String, LocationTypesDto> getLocationTypesDropdown() {
        return locationTypesDropdown;
    }

    public void setLocationTypesDropdown(Map<String, LocationTypesDto> locationTypesDropdown) {
        this.locationTypesDropdown = locationTypesDropdown;
    }
}
