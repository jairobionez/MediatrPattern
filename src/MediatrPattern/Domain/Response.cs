using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MediatrPattern.Domain
{
    public class Response
    {
        public static Response Ok = new Response();

        private List<ValidationFailure> _validations = new List<ValidationFailure>();
        public object Data { get; set; }
        public bool HasValidation { get; set; }
        public IEnumerable<ValidationFailure> Validations => this._validations;
        public bool HasError { get; set; }
        public ValidationFailure Error { get; set; }

        public Response()
        {
            this.Data = null;
            this.HasError = false;
            this.HasValidation = false;
        }

        public Response(object data)
        {
            this.Data = data;
            this.HasError = false;
            this.HasValidation = false;
        }

        public Response(Exception ex)
        {
            this.Error = new ValidationFailure("$error", ex.Message) { ErrorCode = "500" };
            this.HasError = false;
            this.HasValidation = false;
        }

        public Response(IEnumerable<ValidationFailure> validations)
        {
            this._validations = validations.ToList();
            this.HasError = false;
            this.HasValidation = false;
        }

        public Response(ValidationFailure validation) : this(new[] { validation })
        {
        }

        public Response(string propertyName, string errorMessage) : this (new ValidationFailure(propertyName, errorMessage))
        { 
        }
    }
}
