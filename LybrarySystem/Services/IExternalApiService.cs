using System.Threading.Tasks;

public interface IExternalApiService
{
    Task<string> GetQuestions();
    Task<string> GetQuestionDetails(int questionId);
}
