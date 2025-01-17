﻿using Domain;

namespace Application
{
    public class GetUserWorkflowQueryHandler : IRequestHandler<GetUserWorkflowsQuery, IReadOnlyCollection<Domain.CandidateWorkflow>>
    {
        private readonly ICandidateWorkflowRepository _workflowRepository;

        public GetUserWorkflowQueryHandler(ICandidateWorkflowRepository workflowRepository)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(workflowRepository));

            _workflowRepository = workflowRepository ?? throw new ArgumentNullException(nameof(workflowRepository));
        }

        public async Task<IReadOnlyCollection<Domain.CandidateWorkflow>> Handle(GetUserWorkflowsQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var workflows = await _workflowRepository.GetByUserId(request.UserId, request.IsOpenOnly, cancellationToken).ConfigureAwait(false);

            return workflows.Select(w => Domain.CandidateWorkflow.Create(WorkflowTemplate.Create("", "", []))).ToArray();
        }
    }
}