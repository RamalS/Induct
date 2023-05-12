import FileUploader from "../DragDropFiles/FileUploader";
import React, { useState, useEffect, useRef } from "react";
import "./File.scss";

type Props = {
  name: string;
  onChange: ((arg0: File | File[]) => void) | undefined;
  multiple?: boolean;
};

export const File = ({ name, onChange, multiple }: Props) => {
  return (
    <React.Fragment>
      <div className="file-container">
        {/* <input
          type="file"
          name={name}
          onChange={onChange}
          multiple={multiple}
        /> */}
        <FileUploader
          handleChange={onChange}
          classes="file-uploader file-uploader-zone"
          name={name}
          multiple={multiple}
          types={["json"]}
          label="Choose a file or drag it here."
        />
      </div>
    </React.Fragment>
  );
};
