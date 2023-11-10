import React, { useState } from "react";
import { Map, InfoWindow, Marker, GoogleApiWrapper } from "google-maps-react";

const Location = (props) => {
  const [state, setState] = useState({
    showingInfoWindow: false,
    activeMarker: {},
    selectedPlace: {},
  });

  const onMarkerClick = (props, marker, e) =>
    setState((prevState) => ({
      ...prevState,
      selectedPlace: props,
      activeMarker: marker,
      showingInfoWindow: true,
    }));

  const onInfoWindowClose = () =>
    setState({
      showingInfoWindow: false,
      activeMarker: null,
      selectedPlace: {},
    });

  return (
    <div>
      <Map google={props.google} zoom={14}>
        <Marker onClick={onMarkerClick} name={"Current location"} />

        <InfoWindow
          marker={state.activeMarker}
          visible={state.showingInfoWindow}
          onClose={onInfoWindowClose}
        >
          <div>
            <h1>{state.selectedPlace.name}</h1>
          </div>
        </InfoWindow>
      </Map>
    </div>
  );
};

export default GoogleApiWrapper({
  apiKey: "AIzaSyDT29WC2wSHhEhnh-_fbzwsSJF5Ja6AMyo",
})(Location);
