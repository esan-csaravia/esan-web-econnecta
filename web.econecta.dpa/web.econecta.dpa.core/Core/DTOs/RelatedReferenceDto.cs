namespace web.econecta.dpa.core.Core.DTOs
{
    public sealed class RelatedReferenceDto
    {
        public string Controller { get; set; } = null!;
        public long Id { get; set; }
        public string Url { get; set; } = null!;
    }
}
