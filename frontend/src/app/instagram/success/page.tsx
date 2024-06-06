'use client';

import { useEffect, useState } from 'react';
import { useSession } from 'next-auth/react';

export default function Success(req: Request, res: Response) {
  const { data: session } = useSession();

  const url = window.location.href;
  const newUrl = new URLSearchParams(url);
  const token = newUrl.get('long_lived_token');
  console.log(token);

  interface InstagramUserDetail {
    accessToken: string | null;
    user: { email: string | null | undefined };
  }

  const [userDetail, setUserDetail] = useState<InstagramUserDetail | null>(
    null
  );

  useEffect(() => {
    setUserDetail({
      accessToken: token,
      user: { email: session?.user?.email },
    });
    async function fetchToken() {
      await fetch('https://localhost:7112/api/instagramuser/', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(userDetail),
      });
    }
    fetchToken();
  }, [token, session, userDetail]);

  return (
    <>
      <h2>Instagram access token:</h2>
      <p>{token}</p>
    </>
  );
}
