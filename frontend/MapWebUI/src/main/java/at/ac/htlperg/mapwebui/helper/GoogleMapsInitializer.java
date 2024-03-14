package at.ac.htlperg.mapwebui.helper;

public class GoogleMapsInitializer {
    public static String getApiKey() {
        String apiKey = System.getenv("MAP_KEY");

        if(apiKey == null || apiKey.isEmpty()) {
            System.err.println("Error: Google Maps API key not found in environment variables.");
            return null;
        }

        return apiKey;
    }
}