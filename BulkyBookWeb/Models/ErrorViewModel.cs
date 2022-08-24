// model represents the shape of the data
// responds to all data related logic which user works with
// respresents all the data in application - Table in SQL server / combination of multiple tables, etc.
// represents data trasferred between Views and Controllers or other Models
// 10 tables in database => have atleast 10 Models that corresponds to them

// View - represents the user interface with which the user interacts
// html, css files
// displayed to the user directly on the website
// View - interact with Model using controller to display different data

// Controller - interface between Model and View to process all business logic and incoming req
// manipulates data using Model, handles user request
// interacts with View to render final output

namespace BulkyBookWeb.Models
{
    // all tables in database -> class file = Model
    public class ErrorViewModel
    {
        // columns of table => properties of class file
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}