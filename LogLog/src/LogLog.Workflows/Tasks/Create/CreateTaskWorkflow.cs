using LogLog.UseCases;
using LogLog.UseCases.Tasks.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLog.Workflows.Tasks.Create
{
    public class CreateTaskWorkflow : IWorkflow<CreateTaskWorkflowRequest, CreateTaskWorkflowResponse>
    {
        private readonly IUseCase<CreateTaskUseCaseRequest, CreateTaskUseCaseResponse> _createTaskUseCase;

        public CreateTaskWorkflow(IUseCase<CreateTaskUseCaseRequest, CreateTaskUseCaseResponse> createTaskUseCase)
        {
            _createTaskUseCase = createTaskUseCase;
        }

        public async Task<CreateTaskWorkflowResponse> ExecuteAsync(CreateTaskWorkflowRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
