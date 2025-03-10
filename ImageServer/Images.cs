﻿namespace ImageServer;

public class Images
{
    public static List<ImageResponse> LocalhostImages() =>
    [
        new(
            Type: "favicon",
            CompanyName: "Local Magic",
            Description: "Local Favicon",
            FileName: "favicon.svg",
            Base64Content: "",
            SvgContent: LocalhostFaviconSvg,
            ImageFormat: "image/svg+xml",
            Height: 50,
            Width: 50)
    ];

    public static List<ImageResponse> CloudFrontImages() =>
    [
        new(
            Type: "favicon",
            CompanyName: "Staging",
            Description: "CloudFront Favicon",
            FileName: "favicon.svg",
            Base64Content: "",
            SvgContent: CloudFrontFaviconSvg,
            ImageFormat: "image/svg+xml",
            Height: 2642,
            Width: 3657)
    ];

    private static string LocalhostFaviconSvg => """
        <svg viewBox=\"0 0 50 50\" xmlns=\"http://www.w3.org/2000/svg\">
            <path d=\"m3.935 6.648 16.254 13.674-16.254 13.698-3.7379-3.8103 11.937-9.8392-11.937-9.9115z\"/>
            <path d=\"m22.649 43.352v-4.6543h27.154v4.6543z\"/>
        </svg>
        """;

    private static string CloudFrontFaviconSvg => """
        <svg viewBox=\"0 0 3656.7 2642.2\" xmlns=\"http://www.w3.org/2000/svg\">
            <style type=\"text/css\">.st0{fill:#5E1F18;}.st1{fill:#8C3123;}.st2{fill:#E05243;}.st3{fill:#F2B0A9;}</style>
            <path class=\"st0\" d=\"M2136.9,1105.7l480.5-51.3l249,51.7l0.9,0.6l-459.1,27.4l-271.8-27.9L2136.9,1105.7L2136.9,1105.7z\"/>
            <path class=\"st1\" d=\"M2136.4,1106.2l480.6-37.5l3.3-4.8l0-592.9l-3.3-6.8l-480.6,125V1106.2\"/>
            <path class=\"st2\" d=\"M2867.3,1106.7l-250.3-38.1l0-604.5l250.3,125.2L2867.3,1106.7\"/>
            <path class=\"st3\" d=\"M2136.4,1533.1l7,4.9l473.6,32.1l241.7-32.1l8.6-4.7l-459.1-28.2L2136.4,1533.1\"/>
            <path class=\"st1\" d=\"M2136.4,1533.1l480.6,35.8l1.5,2l-0.4,600.2l-1.2,3.1l-480.6-124L2136.4,1533.1\"/>
            <path class=\"st2\" d=\"M2867.3,1533.3l-250.2,35.5l-0.1,605.3l250.3-124.3V1533.3\"/>
            <path class=\"st0\" d=\"M1512.7,1105.3l-475.1-40.7l-246.7,41l-1.6,1.2l459.1,27.4l266.8-27.4L1512.7,1105.3L1512.7,1105.3z\"/>
            <path class=\"st1\" d=\"M789.4,1106.7l248-36.3l7.3-5.2V471.1l-7.3-6.9l-248,125.3V1106.7\"/>
            <path class=\"st2\" d=\"M1515.3,1106.7l-477.9-36.3V464.2l477.9,125L1515.3,1106.7\"/>
            <path class=\"st3\" d=\"M1515.3,1533.3l-11,8l-466.9,35l-240.1-35l-7.9-8l459.1-28.2L1515.3,1533.3\"/>
            <path class=\"st1\" d=\"M789.4,1533.3l248,35.2l6.3,7.7l0.7,587.1l-7,10.8l-248-124.3L789.4,1533.3\"/>
            <path class=\"st2\" d=\"M1515.3,1533.3l-477.9,35.2l0,605.6l477.9-124V1533.3\"/>
            <path class=\"st3\" d=\"M2324.3,1610.6l-496-48.9l-500.9,48.9l7.1,6l491.4,78.1l491.3-78.1L2324.3,1610.6\"/>
            <path class=\"st1\" d=\"M1327.4,1610.6l498.5,73l5.1,6.8l0.6,868.2l-5.7,9.6l-498.5-249.2L1327.4,1610.6\"/>
            <path class=\"st2\" d=\"M2324.3,1610.6l-498.4,73v884.6l498.4-249.2L2324.3,1610.6\"/>
            <path class=\"st0\" d=\"M1828.3,1077.1l-500.9-48.4l1.3-0.7l497.2-77.1l496.9,77.3l1.5,0.6L1828.3,1077.1z\"/>
            <path class=\"st1\" d=\"M1327.4,1028.7l498.5-72.6l2.4-2.2l-1.1-881.4l-1.3-1.3l-498.5,249.3V1028.7\"/>
            <path class=\"st2\" d=\"M2324.3,1028.7l-498.4-72.6v-885l498.4,249.3V1028.7\"/>
        </svg>
        """;
}
