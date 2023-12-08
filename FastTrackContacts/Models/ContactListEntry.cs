using System.ComponentModel.DataAnnotations;

namespace FastTrackContacts.Models;

public class ContactListEntry
{
    public int Id { get; set; }
    public ContactType ContactType { get; set; }
    public required string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public required string Address { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
}
