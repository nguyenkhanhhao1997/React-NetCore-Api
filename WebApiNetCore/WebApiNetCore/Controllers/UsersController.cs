using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiNetCore.Models;
using System.IO;
using System.Security.Cryptography;
using static WebApiNetCore.Models.FormModelView;

namespace WebApiNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public EFDataContext _db;
        public UsersController(EFDataContext db)
        {
            this._db=db;
        }
        [HttpPost]
        [Route("login")]
        public ActionResult PostLogin(FormUserView _user)
        {
             try
              {
                  var check = _db.Users.Where(s => s.Email == _user.Email && s.Password == GetMD5(_user.Password)).FirstOrDefault();
                  if (check.idUser>0)
                  {
                      return Ok(check);
                  }
                  return Ok(0);
 
              }
             catch(Exception e)
              {
                return Ok(e);
              }
            
        }
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Post([FromForm] FormUserView _user)
        {
            var check = _db.Users.Where(s => s.Email == _user.Email.ToLower()).ToList();
            if (check.Count() > 0)
            {
                return Ok(-1);
            }
            var user = new User
            {
                Name = _user.Name,
                Age = _user.Age,
                Email = _user.Email.ToLower(),
                Address = _user.Address,
                Password = GetMD5(_user.Password),
                BirthDay = _user.BirthDay
 
            };
            var filesPath = Directory.GetCurrentDirectory() + "/images";
            //get filename
            if (_user.Avatar != null)
            {
                string ImageName = Path.GetFileName(_user.Avatar.FileName);
                var fullFilePath = Path.Combine(filesPath, ImageName);
                using (var stream = new FileStream(fullFilePath, FileMode.Create))
                {
                    await _user.Avatar.CopyToAsync(stream);
                }
                user.Avatar = filesPath + "/" + ImageName;
            }    
            
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            int _insertID = user.idUser;
            if (_insertID > 0)
            {
                return Ok(_insertID);
            }
            return Ok(0);
        }
        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;
 
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
 
            }
            return byte2String;
        }
    }
}

