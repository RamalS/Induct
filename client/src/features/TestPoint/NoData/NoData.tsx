import React, { useState, useEffect } from "react";
import NoDataSvg from "../../../assets/nodata.svg";

import "./NoData.scss";

export const NoData = () => {
  return (
    <>
      <div className="no-data-container">
        <div className="no-data">
          <img src={NoDataSvg} />
          <h3>No data</h3>
          <p>
            Lorem ipsum dolor sit amet consectetur, adipisicing elit. Voluptate
            maiores animi omnis neque saepe deleniti.
          </p>
        </div>
      </div>
    </>
  );
};
