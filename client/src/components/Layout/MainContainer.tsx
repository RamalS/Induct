import React, { useState, useEffect } from "react";

type Props = {
  children: React.ReactNode;
};

export const MainContainer = ({ children }: Props) => {
  return (
    <>
      <div className="main-container">{children}</div>
    </>
  );
};
