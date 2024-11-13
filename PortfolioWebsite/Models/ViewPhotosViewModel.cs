namespace PortfolioWebsite.Models
{
    /// <summary>
    /// Used to send a specific set of photos to 
    /// the View Photos page for display
    /// </summary>
    public class ViewPhotosViewModel
    {
        // Contains a list of Photo objects to 
        // be sent to a view, these will be 
        // organized in the ViewPhotos section 
        // of the PhotoController
        public List<Photo>? Photos { get; set; }
    }
}
