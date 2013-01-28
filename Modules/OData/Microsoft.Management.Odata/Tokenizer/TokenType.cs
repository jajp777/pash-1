namespace Tokenizer
{
	internal enum TokenType
	{
		None,
		StartOfInput,
		EndOfInput,
		Failure,
		Whitespace,
		Identifier,
		Alias,
		Pragma,
		Comma,
		Colon,
		Semicolon,
		Equals,
		OpenParens,
		CloseParens,
		OpenBracket,
		CloseBracket,
		OpenBrace,
		CloseBrace,
		StringPart,
		StringValue,
		Character,
		Integer,
		Real
	}
}