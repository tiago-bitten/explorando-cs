namespace UploadImage.Dtos
{
    public class ReadProductImagesDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public ReadProductDto Product { get; set; }
    }
}
