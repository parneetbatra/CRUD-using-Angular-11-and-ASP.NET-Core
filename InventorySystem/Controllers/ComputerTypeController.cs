using InventorySystem.Models;
using InventorySystem.Repository;
using InventorySystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerTypeController : ControllerBase
    {
        IComputerTypeRepository computerTypeRepository;
        public ComputerTypeController(IComputerTypeRepository _computerTypeRepository)
        {
            computerTypeRepository = _computerTypeRepository;
        }

        // GET: api/<ComputerTypeController>
        [HttpGet]
        public ActionResult<List<ComputerType>> Get()
        {
            List<ComputerType> ComputerTypeList = new List<ComputerType>();
            try
            {
                ComputerTypeList = computerTypeRepository.GetAll();
                return Ok(ComputerTypeList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            finally
            {
                ComputerTypeList = null;
            }
        }

        // GET api/<ComputerTypeController>/5
        [HttpGet("{id}")]
        public ActionResult<ComputerType> Get(int? id)
        {
            ComputerType computerType = new ComputerType();
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }
                computerType = computerTypeRepository.GetById(id);
                if (computerType == null)
                {
                    return NotFound();
                }

                return Ok(computerType);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<ComputerTypeController>
        [HttpPost]
        public ActionResult<ComputerType> Post([FromBody] ComputerType model)
        {
            ComputerType computerType = new ComputerType();
            try
            {
                if (model.Name != null && ModelState.IsValid)
                {
                    computerType = computerTypeRepository.Add(model);
                    return Ok(computerType);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            finally
            {
                computerType = null;
            }
        }

        // PUT api/<ComputerTypeController>/5
        [HttpPut("{id}")]
        public ActionResult<ComputerType> Put(int id, [FromBody] ComputerType model)
        {
            ComputerType computerType = new ComputerType();
            try
            {
                if (ModelState.IsValid)
                {
                    computerType = computerTypeRepository.Update(model);
                    return Ok(computerType);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            finally
            {
                computerType = null;
            }
        }

        // DELETE api/<ComputerTypeController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            int result = 0;

            try
            {
                result = computerTypeRepository.Delete(id);
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
