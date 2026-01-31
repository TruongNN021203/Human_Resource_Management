
using Shared.Kernel.Common;

public class AccountContract : Entity
{
    public long AccountId { get; set; }
    public string? PlaceOfBirth { get; set; }
    public string? Hometown { get; set; }
    public string? PermanentAddress { get; set; }
    public string? TemporaryAddress { get; set; }
    public string? Ethnicity { get; set; }
    public string? Religion { get; set; }
    public string? Nationality { get; set; }
    public AccountContract(
        long accountId,
        string placeOfBirth,
        string hometown,
        string permanentAddress,
        string temporaryAddress,
        string ethnicity,
        string religion,
        string nationality
    )
    {
        Id = IdGenerator.NewId();
        AccountId = accountId;
        PlaceOfBirth = placeOfBirth;
        Hometown = hometown;
        PermanentAddress = permanentAddress;
        TemporaryAddress = temporaryAddress;
        Ethnicity = ethnicity;
        Religion = religion;
        Nationality = nationality;
    }

}
