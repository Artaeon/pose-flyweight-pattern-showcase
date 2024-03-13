package at.ac.htlperg.mapwebui.helper;

import java.io.FileInputStream;
import java.io.IOException;
import java.util.Properties;

public class ConfigReader {
    public static String readKeyConfig() {
        Properties properties = new Properties();
        FileInputStream inputStream = null;

        try {
            inputStream = new FileInputStream("config.ini");

            properties.load(inputStream);

            return properties.getProperty("key");
        } catch (IOException e) {
            System.out.println(e);
        } finally {
            if (inputStream != null) {
                try {
                    inputStream.close();
                } catch (IOException e) {
                    System.out.println(e);
                }
            }
        }
        return null;
    }
}

