using Microsoft.Data.Edm;
using Microsoft.Data.Edm.Csdl.Internal;
using Microsoft.Data.Edm.Csdl.Internal.Parsing.Ast;
using Microsoft.Data.Edm.Expressions;
using Microsoft.Data.Edm.Internal;
using Microsoft.Data.Edm.Validation;
using Microsoft.Data.Edm.Values;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Data.Edm.Csdl.Internal.CsdlSemantics
{
	internal class CsdlSemanticsDateTimeOffsetConstantExpression : CsdlSemanticsExpression, IEdmDateTimeOffsetConstantExpression, IEdmExpression, IEdmDateTimeOffsetValue, IEdmPrimitiveValue, IEdmValue, IEdmElement, IEdmCheckable
	{
		private readonly CsdlConstantExpression expression;

		private readonly Cache<CsdlSemanticsDateTimeOffsetConstantExpression, DateTimeOffset> valueCache;

		private readonly static Func<CsdlSemanticsDateTimeOffsetConstantExpression, DateTimeOffset> ComputeValueFunc;

		private readonly Cache<CsdlSemanticsDateTimeOffsetConstantExpression, IEnumerable<EdmError>> errorsCache;

		private readonly static Func<CsdlSemanticsDateTimeOffsetConstantExpression, IEnumerable<EdmError>> ComputeErrorsFunc;

		public override CsdlElement Element
		{
			get
			{
				return this.expression;
			}
		}

		public IEnumerable<EdmError> Errors
		{
			get
			{
				return this.errorsCache.GetValue(this, CsdlSemanticsDateTimeOffsetConstantExpression.ComputeErrorsFunc, null);
			}
		}

		public override EdmExpressionKind ExpressionKind
		{
			get
			{
				return EdmExpressionKind.DateTimeOffsetConstant;
			}
		}

		public IEdmTypeReference Type
		{
			get
			{
				return null;
			}
		}

		public DateTimeOffset Value
		{
			get
			{
				return this.valueCache.GetValue(this, CsdlSemanticsDateTimeOffsetConstantExpression.ComputeValueFunc, null);
			}
		}

		public EdmValueKind ValueKind
		{
			get
			{
				return this.expression.ValueKind;
			}
		}

		static CsdlSemanticsDateTimeOffsetConstantExpression()
		{
			CsdlSemanticsDateTimeOffsetConstantExpression.ComputeValueFunc = (CsdlSemanticsDateTimeOffsetConstantExpression me) => me.ComputeValue();
			CsdlSemanticsDateTimeOffsetConstantExpression.ComputeErrorsFunc = (CsdlSemanticsDateTimeOffsetConstantExpression me) => me.ComputeErrors();
		}

		public CsdlSemanticsDateTimeOffsetConstantExpression(CsdlConstantExpression expression, CsdlSemanticsSchema schema) : base(schema, expression)
		{
			this.valueCache = new Cache<CsdlSemanticsDateTimeOffsetConstantExpression, DateTimeOffset>();
			this.errorsCache = new Cache<CsdlSemanticsDateTimeOffsetConstantExpression, IEnumerable<EdmError>>();
			this.expression = expression;
		}

		private IEnumerable<EdmError> ComputeErrors()
		{
			DateTimeOffset? nullable;
			if (EdmValueParser.TryParseDateTimeOffset(this.expression.Value, out nullable))
			{
				return Enumerable.Empty<EdmError>();
			}
			else
			{
				EdmError[] edmError = new EdmError[1];
				edmError[0] = new EdmError(base.Location, EdmErrorCode.InvalidDateTimeOffset, Strings.ValueParser_InvalidDateTimeOffset(this.expression.Value));
				return edmError;
			}
		}

		private DateTimeOffset ComputeValue()
		{
			DateTimeOffset? nullable;
			if (EdmValueParser.TryParseDateTimeOffset(this.expression.Value, out nullable))
			{
				return nullable.Value;
			}
			else
			{
				return DateTimeOffset.MinValue;
			}
		}
	}
}