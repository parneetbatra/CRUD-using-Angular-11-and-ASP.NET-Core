using InventorySystem.Models;
using InventorySystem.Repository;
using InventorySystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        IPropertiesRepository propertiesRepository;
        public PropertiesController(IPropertiesRepository _propertiesRepository)
        {
            propertiesRepository = _propertiesRepository;
        }

        // GET: api/<PropertiesController>
        [HttpGet]
        public ActionResult<List<ComputerView>> Get()
        {
            List<ComputerView> computerViewList = new List<ComputerView>();
            try
            {
                computerViewList = propertiesRepository.GetAll();
                if (computerViewList == null)
                {
                    return NotFound();
                }

                return Ok(computerViewList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            finally
            {
                computerViewList = null;
            }
        }

        // GET api/<PropertiesController>/5
        [HttpGet("{id}")]
        public ActionResult<ComputerView> Get(int? id)
        {
            ComputerView computerView = new ComputerView();
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }

                computerView = propertiesRepository.GetById(id);

                if (computerView == null)
                {
                    return NotFound();
                }

                return Ok(computerView);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            finally
            {
                computerView = null;
            }
        }

        // POST api/<PropertiesController>
        [HttpPost]
        public ActionResult<Properties> Post([FromBody] Properties model)
        {
            Properties properties = new Properties();
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        properties = propertiesRepository.Add(model);
                        if (properties.Id > 0)
                        {
                            return Ok(properties);
                        }
                        else
                        {
                            return NotFound();
                        }
                    }
                    catch (Exception)
                    {
                        return BadRequest();
                    }
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            finally
            {
                properties = null;
            }
        }

        // PUT api/<PropertiesController>/5
        [HttpPut("{id}")]
        public ActionResult<Properties> Put(int id, [FromBody] Properties model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        return Ok(propertiesRepository.Update(model));
                    }
                    catch (Exception)
                    {
                        return BadRequest();
                    }
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<PropertiesController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            int result = 0;

            try
            {
                result = propertiesRepository.Delete(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
