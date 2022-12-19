using Amazon.Lambda.Core;
using System.Net.Http.Headers;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWS.Lambda.Example;

public class Function
{
    public Response FunctionHandler(Person person, ILambdaContext context)
    {
        if (person.Age < 18)
            throw new Exception("The relevant person cannot be under the age of 18!");
        return new Response()
        {
            Message = "The person has been verified!"
        };
    }
}

public class Person
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
}
public class Response
{
    public string Message { get; set; }
}