namespace Planet.Domain.Boards
{
    [Flags]
    public enum BoardPermissions : short
    {
        View = 0,
        ChangeSpecs = 1,
        InviteMember = 2,
        EditCard = 4,
        EditList = 8,
        All = View | ChangeSpecs | InviteMember | EditCard | EditList
    }
}
