namespace TrackApp.Model
{
	internal class EmployeeStatus
	{
		public int Id { get; set; }
		public int SafescanId { get; set; }
		public string Start { get; set; }
		public string End { get; set; }
		public string Status { get; set; }
		public int Multiple { get; set; }
		public int DeviceId { get; set; }
		public int SystemChanges { get; set; }
		public int RemoteConnection { get; set; }
	}
}