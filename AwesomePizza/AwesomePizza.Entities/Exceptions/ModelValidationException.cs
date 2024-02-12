namespace AwesomePizza.Models.Exceptions;
public class ModelValidationException(Exception e) : Exception("Invalid model", e);
