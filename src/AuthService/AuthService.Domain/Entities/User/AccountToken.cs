using AuthService.Domain.Entities;
using Shared.Kernel.Common;

namespace Domain.Aggregates.Accounts;

public class AccountToken : Entity
{
    public string? Token { get; set; }
    public string? ClientIp { get; set; }
    public string? FamilyId { get; set; }
    public long AccountId { get; set; }
    public Account? Account { get; set; }
    public int ExpiredTime { get; set; }
}