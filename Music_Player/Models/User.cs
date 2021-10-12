using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Music_Player.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Пожалуйста введите свое имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Вы должны ввести свой электронный адрес")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Пожалуйста введите пароль")]
        public string Password { get; set; }
        public bool Dispatched { get; set; }
        public virtual List<UserLine> UserLines { get; set; }
    }
    public class UserLine
    {
        public int UserLineId { get; set; }
        public User User { get; set; }
        public Song Song { get; set; }
    }
}