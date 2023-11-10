import React, { useState, useEffect } from "react";
import "../Styles/shopping.css";
import axios from "axios";

const Shopping = () => {
  const [data, setData] = useState([]);

  const [inputValues, setInputValues] = useState({});

  const handleInputChange = (e, vegName) => {
    setInputValues((prevValues) => ({
      ...prevValues,
      [vegName]: e.target.value,
    }));
  };
  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get(
          "https://localhost:7067/api/Vegetable"
        );
        setData(response.data.value);
        console.log(response);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };

    fetchData();
  }, []);

  const handleSubmit = (event) => {
    event.preventDefault();

    console.log("Input value:", inputValues);
  };

  return (
    <div>
      <div className="details d-flex justify-content-center mt-4">
        <table className="table table-bordered w-50">
          <thead className="Thead">
            <tr>
              <th>VEGETABLES</th>
              <th>PRICE</th>
            </tr>
          </thead>
          <tbody>
            {data.map((item) => (
              <tr key={item.vegName}>
                <td>{item.vegName}</td>
                <td>
                  <input
                    type="text"
                    value={inputValues[item.vegName] || ""}
                    onChange={(e) => handleInputChange(e, item.vegName)}
                  />
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      <button type="submit" onClick={handleSubmit}>
        Submit
      </button>
    </div>
  );
};

export default Shopping;
