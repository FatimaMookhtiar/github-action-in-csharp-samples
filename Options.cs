using CommandLine;

public class Options
{
	[Option('f', "firstname", Required = false, HelpText = "Your First Name")]
	public string FirstName { get; set; }

	[Option('l', "lastname", Required = false, HelpText = "Your Last Name")]
	public string LastName { get; set; }
}