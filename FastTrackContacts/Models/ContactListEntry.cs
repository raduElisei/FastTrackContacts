using System.ComponentModel.DataAnnotations;

namespace FastTrackContacts.Models;

public class ContactListEntry
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public ContactType ContactType { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    [Required]
    [MaxLength(200)]
    public string Address { get; set; } = string.Empty;
    [Required]
    public string PhoneNumber { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
}
