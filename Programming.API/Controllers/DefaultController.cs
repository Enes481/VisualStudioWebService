using Programming.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace Programming.API.Controllers
{
    public class DefaultController : ApiController
    {

        calisanDAL calisanlarDAL = new calisanDAL();
        [ResponseType(typeof(IEnumerable<calisanlar>))]
        [System.Web.Http.Authorize]
        public IHttpActionResult Get()
        {
            var calisanlar =  calisanlarDAL.GetAllCalisanlar();
            return Ok(calisanlar);
        }


       

        [System.Web.Http.Authorize]
        public IHttpActionResult Get(int id)
        {
                         
                var calisan = calisanlarDAL.GetCalisanlarId(id);
                if (calisan == null)
                {
                    return NotFound();
                }
                return Ok(calisan);
 
        }

        [ResponseType(typeof(calisanlar))]
        public IHttpActionResult Post(calisanlar calisan)   
        {
            if (ModelState.IsValid)
            {
                var  createCalisan = calisanlarDAL.CreateCalisanlar(calisan);
                return CreatedAtRoute("DefaultApi", new { id = createCalisan.ID },createCalisan);
            }
            else
            {
                return BadRequest(ModelState);
            }

           
        }
        [ResponseType(typeof(calisanlar))]
        public IHttpActionResult Put(int id, calisanlar calisan)
        {

            if (calisanlarDAL.IsThereAnyCalisan(id) == false)  // id ye ait kayıt yok ise 
            {
                return NotFound();
            }

            else if (ModelState.IsValid == false)              //calisan modeli doğru girilmediyse
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(calisanlarDAL.UpdateCalisanlar(id,calisan));                                    //Herşey yolunda ise 
            }
            
        }

        public IHttpActionResult Delete(int id)
        {
            if(calisanlarDAL.IsThereAnyCalisan(id) == false)
            {
                return NotFound();
            }
            else
            {
                calisanlarDAL.DeleteCalisan(id);
                return Ok();
            }
            
        }
    }
}