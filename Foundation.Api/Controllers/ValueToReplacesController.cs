﻿namespace Foundation.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using Foundation.Api.Mediator.Commands;
    using Foundation.Api.Mediator.Queries;
    using Foundation.Api.Models;
    using Foundation.Api.Models.Pagination;
    using MediatR;
    using Microsoft.AspNetCore.JsonPatch;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/v1/ValueToReplaceLowers")]
    public class ValueToReplacesController : Controller
    {
        private readonly IMediator _mediator;

        public ValueToReplacesController(IMediator mediator)
        {
            _mediator = mediator ??
                throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetValueToReplaces")]
        public IActionResult GetCategories([FromQuery] ValueToReplaceParametersDto valueToReplaceParametersDto)
        {
            var query = new GetAllValueToReplacesQuery(valueToReplaceParametersDto, this);
            var result = _mediator.Send(query);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(result.Result.PaginationMetadata));

            return Ok(result.Result.ValueToReplaceDtoList);
        }

        [HttpGet("{valueToReplaceId}", Name = "GetValueToReplace")]
        public IActionResult GetValueToReplace(int valueToReplaceId)
        {
            var query = new GetValueToReplaceQuery(valueToReplaceId, this);
            var result = _mediator.Send(query);

            return result.Result;
        }

        [HttpPost]
        public ActionResult<ValueToReplaceDto> AddValueToReplace(ValueToReplaceForCreationDto valueToReplaceForCreationDto)
        {
            var command = new CreateValueToReplaceCommand(valueToReplaceForCreationDto, this);
            var result = _mediator.Send(command);

            return result.Result;
        }

        [HttpDelete("{valueToReplaceId}")]
        public IActionResult DeleteValueToReplace(int valueToReplaceId)
        {
            var query = new DeleteValueToReplaceCommand(valueToReplaceId, this);
            var result = _mediator.Send(query);

            return result.Result;
        }

        [HttpPut("{valueToReplaceId}")]
        public IActionResult UpdateValueToReplace(int valueToReplaceId, ValueToReplaceForUpdateDto valueToReplace)
        {
            var command = new UpdateEntireValueToReplaceCommand(valueToReplaceId, valueToReplace, this);
            var result = _mediator.Send(command);

            return result.Result;
        }

        [HttpPatch("{valueToReplaceId}")]
        public IActionResult PartiallyUpdateValueToReplace(int valueToReplaceId, JsonPatchDocument<ValueToReplaceForUpdateDto> patchDoc)
        {
            var command = new UpdatePartialValueToReplaceCommand(valueToReplaceId, patchDoc, this);
            var result = _mediator.Send(command);

            return result.Result;
        }
    }
}