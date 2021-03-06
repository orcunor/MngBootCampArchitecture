using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands
{
    public class CreateModelCommand : IRequest<Model>
    {
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }
        public int BrandId { get; set; }
        public int TransmissionId { get; set; }
        public int FuelId { get; set; }
        public string ImageUrl { get; set; }

        public class CreateModelResponseHandler : IRequestHandler<CreateModelCommand, Model>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;
            private readonly ModelBusinessRules _modelBusinessRules;

            public CreateModelResponseHandler(IModelRepository modelRepository, IMapper mapper,
                                              ModelBusinessRules modelBusinessRules)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
                _modelBusinessRules = modelBusinessRules;
            }

            public async Task<Model> Handle(CreateModelCommand request, CancellationToken cancellationToken)
            {
                await _modelBusinessRules.ModelNameCanNotBeDuplicateWhenInserted(request.Name);

                var mappedModel = _mapper.Map<Model>(request);
                var createdModel = await _modelRepository.AddAsync(mappedModel);
                return createdModel;
            }
        }
    }
}
