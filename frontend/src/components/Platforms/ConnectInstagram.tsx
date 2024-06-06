import { Button } from '@/components/ui/button';
import Link from 'next/link';

export default function ConnectInstagram() {
  const BASE_URL = 'https://www.facebook.com/v19.0/dialog/oauth?';
  const CLIENT_ID = '840265517931622';
  const DISPLAY = 'page';
  const EXTRAS = `{"setup":{"channel":"IG_API_ONBOARDING"}}`;
  const REDIRECT_URI = `https://localhost:3000/instagram/success`;
  const RESPONSE_TYPE = `token`;
  const SCOPE = `instagram_basic,instagram_content_publish,instagram_manage_comments,instagram_manage_insights,pages_show_list,pages_read_engagement,business_management`;

  return (
    <>
      <Button variant="link">
        <Link
          href={`${BASE_URL}client_id=${CLIENT_ID}&display=${DISPLAY}&extras=${EXTRAS}&redirect_uri=${REDIRECT_URI}&response_type=${RESPONSE_TYPE}&scope=${SCOPE}`}
        >
          Connect Instagram
        </Link>
      </Button>
    </>
  );
}
