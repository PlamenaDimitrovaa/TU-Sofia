namespace C__Upr2
{
    public struct GeoPoint
    {
        public float Lat { get; set; }
        public float Lng { get; set; }

        public GeoPoint(float latitude, float longitude)
        {
            Lat = latitude;
            Lng = longitude;
        }
    }
}
