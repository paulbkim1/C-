using System.ComponentModel.DataAnnotations;

public class Survey
{
    [Required(ErrorMessage = "Please input name")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please pick a location")]
    public string Location { get; set; }

    [Required(ErrorMessage = "Please pick your favorite Language")]
    public string Language { get; set; }

    [MinLength(20, ErrorMessage = "Comment must be at least 20 characters")]
    [DataType(DataType.Text)]
    public string Comment { get; set; }
}