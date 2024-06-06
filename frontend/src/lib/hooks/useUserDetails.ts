'use client';

import { useEffect, useState } from 'react';
import { UserDetail } from '../types/user';

export default function useUserDetails() {
  const [userDetails, setUserDetails] = useState<UserDetail | null>(null);

  useEffect(() => {
    const fetchUserDetails = async () => {
      const response = await fetch(
        `https://localhost:7112/api/instagramuser/about`
      );
      const data = await response.json();
      setUserDetails(data);
    };
    fetchUserDetails();
  }, []);

  return userDetails;
}
