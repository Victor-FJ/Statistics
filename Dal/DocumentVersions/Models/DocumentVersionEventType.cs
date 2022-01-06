namespace CC.DAL.Entities
{
    public enum DocumentVersionEventType
    {
        ShareDocInvitationSent,
        ShareDocUserLoggedIn,
        ShareDocForwarded,
        ShareDocDeclined,
        ShareDocExpired,
        ShareDocUserProfileChanged,
        ShareDocQuestionnaireStarted,
        ShareDocQuestionnaireSaved,
        ShareDocExternalFinal,
        DocumentVersionCreated,
        ShareDocQuestionnaireUploadFile
    }
}
