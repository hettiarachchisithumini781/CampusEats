
import { useState } from "react";
import "./App.css";

function App() {
  const API = import.meta.env.VITE_API_URL;
  const [message, setMessage] = useState("");

  const checkAPI = async () => {
    try {
      const response = await fetch(`${API}/api/menu`);

      if (!response.ok) {
        throw new Error("API request failed");
      }

      const data = await response.json();
      console.log(data);
      setMessage("API connected successfully!");
    } catch (error) {
      console.error(error);
      setMessage("Could not connect to the API.");
    }
  };

  return (
    <div style={{ padding: "30px" }}>
      <h1>CampusEats</h1>
      <p>DevOps and Cloud Hosting - Lab 11</p>

      <p>Configured API URL: {API || "Not configured"}</p>

      <button onClick={checkAPI}>
        Test Backend Connection
      </button>

      <p>{message}</p>
    </div>
  );
}

export default App;
