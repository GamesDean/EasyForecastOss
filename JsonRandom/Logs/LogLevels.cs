namespace EasyForecast.SymEngine.Logs
{
    // see post "The role of logs"   https://ayende.com/blog/173761/the-role-of-logs?Key=092123a4-a959-4703-9cbb-96a065a32a9d
    public enum LogLevels
    {
        None = 0,
        Debug = 1,
        Info = 2,
        Warning = 3,
        FatalForInvalidUserActionOrInput = 4,
        FatalForInternalProblem = 5
    }
}

