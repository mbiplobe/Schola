

import React from 'react';

function RegistrationForm(): JSX.Element {
  // simple placeholder implementation to satisfy the reference
  return React.createElement('div', null, 'Registration form');
}

export default function Page() {
  return React.createElement(RegistrationForm);
}