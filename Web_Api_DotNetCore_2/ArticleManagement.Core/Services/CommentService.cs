using CleverbitSoftware.WebApi.Integration.Requests.ArticleManagementRequests;
using CleverbitSoftware.WebApi.Integration.Responses.ArticleManagementResponses;
using FluentValidation;
using ArticleManagement.Core.Events;
using ArticleManagement.Core.Interfaces;
using ArticleManagement.Infrastructure.Data.Interfaces;
using SharedKernel.CleverbitSoftware;
using Dto = CleverbitSoftware.WebApi.Integration.Dtos;
using Entity = ArticleManagement.Infrastructure.Data.Entities;
using Domain = ArticleManagement.Core.Domains;

namespace ArticleManagement.Core.Services
{
    public class CommentService : BaseService, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IValidator<CreateCommentRequest> _createCommentValidator;

        public CommentService(IMapperService mapper,
            ICommentRepository commentRepository,
            IValidator<CreateCommentRequest> createCommentValidator) : base(mapper)
        {
            _commentRepository = commentRepository;
            _createCommentValidator = createCommentValidator;
        }

        #region Public Methods
        public CreateCommentResponse CreateComment(CreateCommentRequest request)
        {
            var response = new CreateCommentResponse();

            var validation = _createCommentValidator.Validate(request);

            if (!validation.IsValid)
            {
                response.ValidationResult = validation;
                return response;
            }

            var entity = Mapper.Map<Entity.Comment>(request);

            response.Comment = Mapper.Map<Dto.Comment>(_commentRepository.CreateComment(entity));

            DomainEvents.Raise(new CommentCreation(Mapper.Map<Domain.Comment>(response.Comment)));

            return response;
        }
        #endregion

        #region Private Methods
        #endregion
    }
}