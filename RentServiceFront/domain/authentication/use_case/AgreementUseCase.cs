using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using RentServiceFront.domain.authentication.repository;
using RentServiceFront.domain.model.request.Agreement;

namespace RentServiceFront.domain.authentication.use_case;

public class AgreementUseCase
{
    private IAgreementRepository _agreementRepository;

    public AgreementUseCase(IAgreementRepository agreementRepository)
    {
        _agreementRepository = agreementRepository ?? throw new ArgumentException("Agreement repository can't be null");
    }

    public async Task<string> createAgreement(CreateAgreementRequest request)
    {
        return await _agreementRepository.createAgreement(request);
    }


    public async Task<string> generateAgreementPdf(long id, string path)
    {
        var response = await _agreementRepository.generateAgreementPdf(id);

        if (response.IsSuccessStatusCode)
        {
            var pdfBytes = await response.Content.ReadAsByteArrayAsync();

            await File.WriteAllBytesAsync(path, pdfBytes);

            return $"PDF файл успешно сохранен по пути: {path}";
        }
        else
        {
            return "Что-то пошло не так.";
        }
    }
}