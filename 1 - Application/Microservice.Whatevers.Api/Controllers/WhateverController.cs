using Microsoft.AspNetCore.Mvc;
using Microservice.Whatevers.Services;
using Microservice.Whatevers.Domain.Entities;
using System.Collections.Generic;
using Microservice.Whatevers.Services.Validators;
using System;

namespace Microservice.Whatevers.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WhateverController : ControllerBase
    {
        private readonly IWhateverService _whateverService;
        private readonly IWhateverValidator _validator;

        public WhateverController(IWhateverService whateverService, IWhateverValidator validator)
        {
            _whateverService = whateverService;
            _validator = validator;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Whatever>> Get()
        {
            var result = _whateverService.Get();

            if (result is null || result.Count == 0)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var whatever = _whateverService.GetById(id);

            if (whatever is null)
                return NotFound();

            return Ok(whatever);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Whatever whatever)
        {
            var validationResult = _validator.Validate(whatever);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            _whateverService.Save(whatever);
            return CreatedAtAction(nameof(GetById), new { id = whatever.Id }, whatever);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Whatever whatever)
        {
            if (id == Guid.Empty)
                return NotFound();

            var whateverFromContext = _whateverService.GetById(id);

            if (whateverFromContext is null)
                return NotFound();

            var validationResult = _validator.Validate(whatever);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            whateverFromContext.Name = whatever.Name;
            whateverFromContext.Things = whatever.Things;
            whateverFromContext.Time = whatever.Time;

            _whateverService.Edit(whateverFromContext);
            return Ok(whateverFromContext);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var whatever = _whateverService.GetById(id);

            if (whatever is null)
                return NotFound();

            _whateverService.Delete(id);
            return NoContent();
        }
    }
}