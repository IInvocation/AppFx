using System;
using FluiTec.AppFx.Identity.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Identity.Test
{
	public class IdentityClaimTest : IdentityTest
	{
		public IdentityClaimTest(IIdentityDataService dataService) : base(dataService)
		{
		}

		public virtual void CanAddAndGetClaim()
		{
			using (var uow = DataService.StartUnitOfWork())
			{
				var user = new IdentityUserEntity
				{
					Identifier = Guid.NewGuid(),
					Name = "Achim Schnell",
					LoweredUserName = "ACHIM SCHNELL",
					Email = "a.schnell@wtschnell.de",
					NormalizedEmail = "A.SCHNELL@WTSCHNELL.DE",
					AccessFailedCount = 0,
					ApplicationId = 0,
					EmailConfirmed = true,
					IsAnonymous = false,
					LastActivityDate = DateTime.Now
				};

				uow.UserRepository.Add(user);

				var claim = new IdentityClaimEntity
				{ 
					UserId = user.Id,
					Type = "Age",
					Value = "18"
				};
				uow.ClaimRepository.Add(claim);
				Assert.AreEqual(claim.Value, uow.ClaimRepository.Get(claim.Id).Value);
			}
		}
	}
}