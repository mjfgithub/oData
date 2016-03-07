using oDataDemo.DataSource;
using oDataDemo.Models;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace oDataDemo.Controllers
{
    [EnableQuery]
    public class PeopleController : ODataController
    {
        public IHttpActionResult Get()
        {
            return Ok(DemoDataSources.Instance.People.AsQueryable());
        }


        public SingleResult<Person> Get([FromODataUri] string key)
        {
            IQueryable<Person> result = DemoDataSources.Instance.People.AsQueryable().Where(p => p.ID == key);
            return SingleResult.Create(result);
        }

        public IHttpActionResult Delete([FromODataUri] string key)
        {

            

            Person person = DemoDataSources.Instance.People.FirstOrDefault(p => p.ID == key);
            if (person == null)
            {
                return NotFound();
            }

            DemoDataSources.Instance.People.Remove(person);
            //db.Products.Remove(product);
            //await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Post([FromBody]Person person)
        {
            string name = person.Name;
            string key = person.ID;
            //HttpResponseMessage response;
            //double salary = entity.Salary;

            try
            {
                Person p1 = DemoDataSources.Instance.People.FirstOrDefault(p => p.ID == key);

                //this is a test
                if(p1 == null)
                {
                    p1 = new Person()
                    {
                        Name = person.Name,
                        ID = person.ID,
                        Description = person.Description                     
                    };

                    DemoDataSources.Instance.People.Add(p1);
                }
                else
                    p1.Name = name;



                //int employeeId = EmployeesHolder.Employees.Max(e => e.Id) + 1;

                //entity.Id = employeeId;
                //EmployeesHolder.Employees.Add(entity);

                //response = Request.CreateResponse(HttpStatusCode.Created, entity);
                //response.Headers.Add("Location", Url.ODataLink(new EntitySetPathSegment("Employees")));
                //return response;

                return Ok();
            }
            catch (Exception)
            {
                //response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                //return response;

                return StatusCode(HttpStatusCode.NoContent);
            }
        }
    }

    [EnableQuery]
    public class TripsController : ODataController
    {
        public IHttpActionResult Get()
        {
            return Ok(DemoDataSources.Instance.Trips.AsQueryable());
        }
    }
}