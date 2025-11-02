namespace JadooTravel.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        /// <summary>
        /// public string CategoryId { get; set; }
        /// </summary>
        public string CategoryName { get; set; }
        public string Description  { get; set; }
        public string IconUrl      { get; set; }
        public bool   Status       { get; set; }
    }
}
