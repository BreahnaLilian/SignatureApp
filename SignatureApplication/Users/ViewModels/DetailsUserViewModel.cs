﻿using MediatR;
using static SignatureCommon.Enums;

namespace SignatureApplication.Users.ViewModels
{
    public class DetailsUserViewModel : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IDNP { get; set; }
        public string Password { get; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public UserStatus Status { get; set; }
    }
}
