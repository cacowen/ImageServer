namespace ImageServer;

public record ImageResponse(
    string Type,
    string CompanyName,
    string Description,
    string FileName,
    string Base64Content,
    string SvgContent,
    string ImageFormat,
    int Height,
    int Width);
