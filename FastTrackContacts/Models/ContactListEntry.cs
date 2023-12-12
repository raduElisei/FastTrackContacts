using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FastTrackContacts.Models;

public class ContactListEntry
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    [DisplayName("Contact type")]
    public ContactType ContactType { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Date of birth")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
    [Required]
    [MaxLength(200)]
    public string Address { get; set; } = string.Empty;
    [Required]
    [DisplayName("Phone number")]
    [RegularExpression(@"^(\+4|)?(\s|\.|\-)?(07[0-8]{1}[0-9]{1}|02[0-9]{2}|03[0-9]{2}){1}?(\s|\.|\-)?([0-9]{3}(\s|\.|\-|)){2}$",
        ErrorMessage = "Invalid phone number")]
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}
