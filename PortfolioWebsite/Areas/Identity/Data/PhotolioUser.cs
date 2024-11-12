using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PortfolioWebsite.Models;

namespace PortfolioWebsite.Areas.Identity.Data;

// Add profile data for application users by adding properties to the PhotolioUser class
public class PhotolioUser : IdentityUser
{
    /// <summary>
    /// Keeps track of all photos uploaded by the user
    /// </summary>
    public List<Photo> UploadedPhotos { get; set; } = new List<Photo>();
}

