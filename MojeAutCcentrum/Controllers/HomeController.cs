using Microsoft.AspNet.Identity.Owin;
using MojeAutCcentrum.Context;
using MojeAutCcentrum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MojeAutCcentrum.Controllers
{
    public class HomeController : Controller
    {
        Connection db = Connection.Create();

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        public ActionResult Index()
        {
            var models = new List<RatingCarViewModels>();
            Brand brand = null;
            Model model = null;
            Generation generation = null;
            Body body = null;
            Motor motor = null;
            bool isAdd = false;
            var data = db.Brand.ToList();
            foreach (var Brand in data)
            {
                brand = Brand;
                isAdd = false;
                if (Brand.Models.FirstOrDefault() != null)
                {
                    foreach (var Model in Brand.Models)
                    {
                        model = Model;
                        isAdd = false;
                        if (Model.Generations.FirstOrDefault() != null)
                        {
                            foreach (var Generations in Model.Generations)
                            {
                                generation = Generations;
                                isAdd = false;
                                if (Generations.Body.FirstOrDefault() != null)
                                {
                                    foreach (var Body in Generations.Body)
                                    {
                                        body = Body;
                                        isAdd = false;
                                        if (Body.Motors.FirstOrDefault() != null)
                                        {
                                            foreach (var Motor in Body.Motors)
                                            {
                                                isAdd = false;
                                                if (!isAdd)
                                                {
                                                    isAdd = true;
                                                    motor = Motor;
                                                    models.Add(new RatingCarViewModels { Brand = brand, Model = model, Generation = generation, Body = body, Motor = motor, number = 0, rating = 0 });
                                                    motor = null;
                                                }
                                            }
                                        }

                                        if (!isAdd)
                                        {
                                            isAdd = true;
                                            models.Add(new RatingCarViewModels { Brand = brand, Model = model, Generation = generation, Body = body, Motor = motor, number = 0, rating = 0 });
                                            model = null;
                                            motor = null;
                                        }
                                    }
                                }

                                if (!isAdd)
                                {
                                    isAdd = true;
                                    models.Add(new RatingCarViewModels { Brand = brand, Model = model, Generation = generation, Body = body, Motor = motor, number = 0, rating = 0 });
                                    model = null;
                                    body = null;
                                    motor = null;
                                }
                            }
                        }

                        if (!isAdd)
                        {
                            isAdd = true;
                            models.Add(new RatingCarViewModels { Brand = brand, Model = model, Generation = generation, Body = body, Motor = motor, number = 0, rating = 0 });
                            model = null;
                            generation = null;
                            body = null;
                            motor = null;
                        }
                    }
                }
                if (!isAdd)
                {
                    isAdd = true;
                    models.Add(new RatingCarViewModels { Brand = brand, Model = model, Generation = generation, Body = body, Motor = motor, number = 0, rating = 0 });
                    brand = null;
                    model = null;
                    generation = null;
                    body = null;
                    motor = null;
                }
            }
            RatingCarViewModels ratingCar;
            foreach (var RatingCar in db.RatingCar.ToList())
            {
                ratingCar = models.FirstOrDefault(x => x.Brand == RatingCar.Brand && x.Body == RatingCar.Body && x.Generation == RatingCar.Generation && x.Model == RatingCar.Model && x.Motor == RatingCar.Motor);
                if (ratingCar != null)
                {
                    ratingCar.rating += ((decimal)(RatingCar.Conveniences.Value + RatingCar.Failure.Value + RatingCar.Maintenance.Value) / 3);
                    ratingCar.number++;
                }
                ratingCar = null;
            }

            foreach (var item in models)
            {
                if (item.number != 0)
                    item.rating = item.rating / item.number;
            }
            return View(models.OrderByDescending(x => x.rating).Take(10));
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(RatingCar model)
        {
            return View();
        }


        [HttpGet]
        public async Task<ActionResult> Car(RCViewVM RatingCarViewVM)
        {
            if (RatingCarViewVM != null)
            {
                decimal Conveniences = 0, Failure = 0, Maintenance = 0;
                int number = 0;
                var comment = new List<Comment>();
                var Brand = db.Brand.FirstOrDefault(x => x.Id == RatingCarViewVM.Brand);
                var Body = db.Body.FirstOrDefault(x => x.Id == RatingCarViewVM.Body);
                var Generation = db.Generation.FirstOrDefault(x => x.Id == RatingCarViewVM.Generation);
                var Model = db.Model.FirstOrDefault(x => x.Id == RatingCarViewVM.Model);
                var Motor = db.Motor.FirstOrDefault(x => x.Id == RatingCarViewVM.Motor);
                var ratingCarList = db.RatingCar.Where(x => x.Brand.Id == Brand.Id);
                if (Model != null) ratingCarList = ratingCarList.Where(x => x.Model.Id == Model.Id);
                if (Generation != null) ratingCarList = ratingCarList.Where(x => x.Generation.Id == Generation.Id);
                if (Body != null) ratingCarList = ratingCarList.Where(x => x.Body.Id == Body.Id);
                if (Motor != null) ratingCarList = ratingCarList.Where(x => x.Motor.Id == Motor.Id);

                foreach (var carRating in ratingCarList.ToList())
                {
                    number++;
                    Conveniences += carRating.Conveniences.Value;
                    Failure += carRating.Failure.Value;
                    Maintenance += carRating.Maintenance.Value;
                    var user = await UserManager.FindByIdAsync(carRating.UserId);
                    var Avatar = db.Avatar.FirstOrDefault(x => x.UserId == carRating.UserId);
                    var Massage = new Massage() { Description = carRating.Description, Conveniences = carRating.Conveniences.Description, Failure = carRating.Failure.Description, Maintenance = carRating.Maintenance.Description };
                    if (Avatar != null)
                    {
                        var Image = Convert.ToBase64String(Avatar.Fream, 0, Avatar.Fream.Length);
                        comment.Add(new Comment { Email = user.Email, Massage = Massage, Image = "data:image/jpeg;base64," + Image });
                    }
                    else
                    {
                        comment.Add(new Comment { Email = user.Email, Massage = Massage });
                    }

                }

                var model = new RatingCarEntityViewModels()
                {
                    Brand = Brand,
                    Body = Body,
                    Generation = Generation,
                    Model = Model,
                    Motor = Motor,
                    Conveniences = Conveniences,
                    Failure = Failure,
                    Maintenance = Maintenance,
                    Comment = comment
                };
                return View(model);
            }

            return View();
        }


        [HttpGet]
        public JsonResult Collection(string NameModel, string Id)
        {
            if (NameModel == "Brand")
            {

            }
            else if (NameModel == "Model")
            {

            }
            else if (NameModel == "Generation")
            {

            }
            else if (NameModel == "Body")
            {

            }
            else if (NameModel == "Motor")
            {

            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}