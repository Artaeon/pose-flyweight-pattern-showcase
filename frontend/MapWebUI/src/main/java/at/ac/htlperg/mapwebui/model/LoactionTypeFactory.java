package at.ac.htlperg.mapwebui.model;

import com.company.api.LocationsApi;
import com.company.model.LocationTypesDto;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class LoactionTypeFactory {
    private List<LocationTypesDto> locationTypes;

    public LoactionTypeFactory(LocationsApi locationsApi) {
        fetchLocationTypes(locationsApi);
    }

    public LocationTypesDto findLocationType(String locationType) {
        if (locationTypes != null) {
            for (LocationTypesDto type : locationTypes) {
                if (type.getTypeName().equals(locationType)) {
                    return type;
                }
            }
        }
        return null;
    }

    public void fetchLocationTypes(LocationsApi locationsApi) {
        try {
            locationTypes = locationsApi.apiLocationsGetLocationTypesGet();

        } catch (Exception e) {
            System.out.println(e);
        }
    }

    public Map<String, LocationTypesDto> loadDropdown(){
        Map<String, LocationTypesDto> locationTypesDropdown = new HashMap<>();
        for (LocationTypesDto l: locationTypes) {
            locationTypesDropdown.put(l.getTypeName(), l);
        }
        return locationTypesDropdown;
    }
}
