namespace AwesomePizza.Web.Dto.Errors;

public static class ErrorCodes
{
    public const string VALIDATION_ERROR = "VALIDATION_ERROR";
    public const string FIELD_VALIDATION_ERROR = "FIELD_INVALID";
    public const string GENERIC = "GENERIC_ERROR";
    public const string ORDER_NOT_FOUND = "ORDER_NOT_FOUND";
    public const string ORDER_WRONG_STATE = "ORDER_WRONG_STATE";
    public const string DISH_NOT_FOUND = "DISH_NOT_FOUND";
    public const string AT_LEAST_ONE_DISH_IS_REQUIRED = "AT_LEAST_ONE_DISH_IS_REQUIRED";
    public const string DUPLIACTED_DISH = "DUPLICATED_DISH";
}