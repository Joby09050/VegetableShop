import React from "react";
import "../Styles/signOut.css";
import { GoSignOut } from "react-icons/go";
const Navbar = () => {
  return (
    <div>
      <div className="nav navbar navbar-expand-lg navbar-light  d-flex justify-content-end ">
        <div className="singnOut me-3 $blue-500">
          <GoSignOut />
        </div>
      </div>
    </div>
  );
};

export default Navbar;
